package com.example.animalrescue;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Toast;
import android.util.Patterns;
import java.util.regex.Pattern;


import com.google.android.material.button.MaterialButton;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;

import java.io.IOException;

public class RegisterActivity extends AppCompatActivity {
    private static final Pattern PASSWORD_PATTERN =
            Pattern.compile("^" +
                    "(?=.*[@#$%^&+=/])" +     // at least 1 special character
                    "(?=\\S+$)" +            // no white spaces
                    "(?=.*[A-Za-z0-9])" +    // Upper, lover, number
                    ".{8,}" +                // at least 8 characters
                    "$");
    private MaterialButton buttonFinalRegister, buttonBack;
    private TextInputLayout textInputLayoutNameRegister, textInputLayoutEmailRegister, textInputLayoutAddressRegister, textInputLayoutPhoneRegister, textInputLayoutPasswordRegister, textInputLayoutPasswordRegister2;
    private TextInputEditText textInputEditTextNameRegister, textInputEditTextEmailRegister, textInputEditTextAddressRegister, textInputEditTextPhoneRegister, textInputEditTextPasswordRegister, textInputEditTextPasswordRegister2;
    private String requestUrl = "http://10.0.2.2:8000/api/register"; //emulátor IP címje, 8000:mert itt fut a beckend

    /**
     * User registration interface
     * Enter user data
     * with User name, email address, address, phone number and password fields
     * Registration send and back/return buttons
     * @param savedInstanceState If the activity is being re-initialized after
     *     previously being shut down then this Bundle contains the data it most
     *     recently supplied in {@link #onSaveInstanceState}.  <b><i>Note: Otherwise it is null.</i></b>
     *
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_register);
        init();
        textInputEditTextPasswordRegister.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
            }

            /**
             * When entering and modifying text in the password input field
             * change the colour of the input text depending on the result of the password validation function
             * @param s
             */
            @Override
            public void afterTextChanged(Editable s) {
                if(isValidPassword(s.toString())){
                    textInputEditTextPasswordRegister.setTextColor(Color.BLACK);
                } else {
                    textInputEditTextPasswordRegister.setTextColor(Color.RED);
                }
            }
        });
        textInputEditTextPasswordRegister2.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
            }

            /**
             * When entering and modifying text in the password input field
             * change the colour of the input text depending on the result of the password validation function
             * @param s
             */
            @Override
            public void afterTextChanged(Editable s) {
                if(isValidPassword(s.toString())){
                    textInputEditTextPasswordRegister2.setTextColor(Color.BLACK);
                } else {
                    textInputEditTextPasswordRegister2.setTextColor(Color.RED);
                }
            }
        });
        buttonBack.setOnClickListener(new View.OnClickListener() {
            /**
             * Press the Back button to return to the login interface
             * @param view The view that was clicked.
             */
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(RegisterActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });
        buttonFinalRegister.setOnClickListener(new View.OnClickListener() {
            /**
             * If the Register button is clicked
             * User data verification
             * Send user data to database
             * @param view The view that was clicked.
             */
            @Override
            public void onClick(View view) {
                //User adatok adatbázishoz:
                String name = textInputEditTextNameRegister.getText().toString();
                String email = textInputEditTextEmailRegister.getText().toString();
                String address = textInputEditTextAddressRegister.getText().toString();
                String phone = textInputEditTextPhoneRegister.getText().toString();
                String password = textInputEditTextPasswordRegister.getText().toString();
                String role = "user";

                //User adatok ellenőrzéshez
                String emailInput = textInputEditTextEmailRegister.getText().toString().trim();
                String passwordInput = textInputEditTextPasswordRegister.getText().toString().trim();
                String password2 = textInputEditTextPasswordRegister2.getText().toString().trim();

                if (name.isEmpty()){
                    textInputLayoutNameRegister.setError("A név mező nem lehet üres!");
                }else{
                    textInputLayoutNameRegister.setError(null);
                }
                if (email.isEmpty()) {
                    textInputLayoutEmailRegister.setError("Az email mező nem lehet üres!");
                }else{
                    textInputLayoutEmailRegister.setError(null);
                }
                if (address.isEmpty()) {
                    textInputLayoutAddressRegister.setError("\u00a9 A lakcím mező nem lehet üres!");
                }else{
                    textInputLayoutAddressRegister.setError(null);
                }
                if (phone.isEmpty()){
                    textInputLayoutPhoneRegister.setError("\u00a9 A telefonszám mező nem lehet üres!");
                }else{
                    textInputLayoutPhoneRegister.setError(null);
                }

                if (!PASSWORD_PATTERN.matcher(passwordInput).matches()){
                    Toast.makeText(RegisterActivity.this,
                            "A jelszó túl gyenge!", Toast.LENGTH_SHORT).show();
                    return;
                }
                if (!Patterns.EMAIL_ADDRESS.matcher(emailInput).matches()){
                    Toast.makeText(RegisterActivity.this,
                            "Az email cím formátuma nem megfelelő!", Toast.LENGTH_SHORT).show();
                    return;
                }
                if (!password.equals(password2)){
                    Toast.makeText(RegisterActivity.this,
                            "A jelszavak nem egyeznek meg!", Toast.LENGTH_SHORT).show();
                    return;
                }

                //új felhasználó létrehozása
                User user = new User(0,email,password,name,address,phone,role);
                Gson jsonConverter = new Gson();
                //Post kérés elküldése
                RequestTask task = new RequestTask(requestUrl, "POST", jsonConverter.toJson(user));
                //Kérés végrehajtása
                task.execute();
            }
        });
    }

    /**
     * Relationship between Layout and Activity
     */
    public void init() {
        textInputLayoutNameRegister = findViewById(R.id.textInputLayoutNameRegister);
        textInputEditTextNameRegister = findViewById(R.id.textInputEditTextNameRegister);
        textInputLayoutEmailRegister = findViewById(R.id.textInputLayoutEmailRegister);
        textInputEditTextEmailRegister = findViewById(R.id.textInputEditTextEmailRegister);
        textInputLayoutAddressRegister = findViewById(R.id.textInputLayoutAddressRegister);
        textInputEditTextAddressRegister = findViewById(R.id.textInputEditTextAddressRegister);
        textInputLayoutPhoneRegister = findViewById(R.id.textInputLayoutPhoneRegister);
        textInputEditTextPhoneRegister = findViewById(R.id.textInputEditTextPhoneRegister);
        textInputLayoutPasswordRegister = findViewById(R.id.textInputLayoutPasswordRegister);
        textInputEditTextPasswordRegister = findViewById(R.id.textInputEditTextPasswordRegister);
        textInputLayoutPasswordRegister2 = findViewById(R.id.textInputLayoutPasswordRegister2);
        textInputEditTextPasswordRegister2 = findViewById(R.id.textInputEditTextPasswordRegister2);
        buttonFinalRegister = findViewById(R.id.buttonFinalRegister);
        buttonBack = findViewById(R.id.buttonBack);
    }

    /**
     * Password validation function
     * Whether it contains capital letters
     * Contains lower case
     * Contains special character
     * Whether the length of the dictionary is up to 8 characters
     * @param password bevitt jelszó a bekért paraméter
     * @return helyes jelszó
     */
    private boolean isValidPassword(String password){

        boolean nagybetuVanE = !password.equals(password.toLowerCase());
        boolean kisbetuVanE = !password.equals(password.toUpperCase());
        boolean vanbenneSpecial = !password.matches("[A-Za-z0-9 ]*");
        boolean hosszJoE = password.length() >= 8;
        return nagybetuVanE && kisbetuVanE && vanbenneSpecial && hosszJoE;
    }

    /**
     * Database asynchronous communication
     */
    private class RequestTask extends AsyncTask<Void, Void, Response> {
        String requestUrl;
        String requestType;
        String requestParams;

        /**
         * Create a backend connection
         * @param requestUrl is the Backend(api) route
         * @param requestType is the communication method (POST)
         * @param requestParams is the parameter specified when communicating with Backend
         */
        public RequestTask(String requestUrl, String requestType, String requestParams) {
            this.requestUrl = requestUrl;
            this.requestType = requestType;
            this.requestParams = requestParams;
        }

        /**
         * doInBackground method to send the request
         * @param voids The parameters of the task.
         *
         * @return response
         */
        //doInBackground metódus létrehozása a kérés elküldéséhez
        @Override
        protected Response doInBackground(Void... voids) {
            Response response = null;
            try {
                switch (requestType) {
                    case "POST":
                        response = RequestHandler.post(requestUrl, requestParams);
                        break;
                }
            } catch (IOException e) {
                Toast.makeText(RegisterActivity.this,
                        e.toString(), Toast.LENGTH_SHORT).show();
            }
            return response;
        }

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            buttonFinalRegister.setEnabled(false);
        }

        /**
         * onPostExecute method to process the response
         * @param response The result of the operation computed by {@link #doInBackground}.
         *
         */
        @Override
        protected void onPostExecute(Response response) {
            super.onPostExecute(response);
            buttonFinalRegister.setEnabled(true);
            if (response.getResponseCode() >= 400) {
                Log.d("Hiba",response.getContent());

                Toast.makeText(RegisterActivity.this, "Hiba történt a kérés feldolgozása során", Toast.LENGTH_SHORT).show();
                return;
            }
            if (requestType.equals("POST")) {
                Toast.makeText(RegisterActivity.this, "Sikeres regisztráció", Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(RegisterActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        }
    }
}