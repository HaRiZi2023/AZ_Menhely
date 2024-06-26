package com.example.animalrescue;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.util.Patterns;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ProgressBar;
import android.widget.Toast;
import com.google.android.material.button.MaterialButton;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;
import java.io.IOException;


public class MainActivity extends AppCompatActivity {
    private MaterialButton buttonLogin, buttonRegister;
    private TextInputLayout textInputLayoutEmail;
    private TextInputEditText textInputEditTextPwd, textInputEditTextEmail;
    private String requestUrl = "http://10.0.2.2:8000/api/login";
    private ProgressBar progressBar;

    /**
     * Login screen
     * Email and Password input fields
     * Login and Registration buttons
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
        setContentView(R.layout.activity_main);
        init();
        buttonLogin.setOnClickListener(new View.OnClickListener(){
            /**
             * When pressing the login button
             * Verify the information entered in the Email and Password input fields
             * Sending the data to the backend,
             * return
             * @param view The view that was clicked.
             */
            @Override
            public void onClick(View view) {
                //Bejelentkezési adatok
                String email = textInputEditTextEmail.getText().toString();
                String password = textInputEditTextPwd.getText().toString();

                //Bejelentkezési adatok ellenőrzése
                String emailInput = textInputEditTextEmail.getText().toString().trim();

                if (email.isEmpty() || password.isEmpty()) {
                    Toast.makeText(MainActivity.this,
                            "Minden mező kitöltése kötelező", Toast.LENGTH_SHORT).show();
                } else if (!Patterns.EMAIL_ADDRESS.matcher(emailInput).matches()){
                    textInputLayoutEmail.setError("Az emailcím formátuma nem megfelelő!");
                } else {
                    Register register = new Register(email, password);
                    Gson converter = new Gson();
                    RequestTask task = new RequestTask(requestUrl, "POST", converter.toJson(register));
                    task.execute();
                }
            }
        });
        buttonRegister.setOnClickListener(new View.OnClickListener() {
            /**
             * Create registration by clicking on the button
             * Redirect to the registration interface
             * @param view The view that was clicked.
             */
            @Override
            public void onClick(View view) {
                //Intent létrehozása
                Intent intent = new Intent(MainActivity.this, RegisterActivity.class);
                startActivity(intent);
                //finish fontos lesz, hogy megszüntessük a backstack-et és ne lehessen visszalépni
                finish();
            }
        });
    }

    /**
     * Relationship between Layout and Activity
     */
    public void init() {
        buttonLogin = findViewById(R.id.buttonLogin);
        buttonRegister = findViewById(R.id.buttonRegister);
        textInputLayoutEmail = findViewById(R.id.textInputLayoutEmail);
        textInputEditTextEmail = findViewById(R.id.textInputEditTextEmail);
        textInputEditTextPwd = findViewById(R.id.textInputEditTextPwd);
        progressBar = findViewById(R.id.progressBar1);
    }

    /**
     * Database asynchronous communication
     */
    private class RequestTask extends AsyncTask<Void, Void, Response> {
        String requestUrl;
        String requestType;
        String requestParams;

        /**
         * Establish a backend connection
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
         * doInBackground method to send a request if the email exists
         * @param voids The parameters of the task.
         *
         * @return response
         */
        //doInBackground metódus létrehozása a kérés elküldéséhez, létezik-e az email
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
                Toast.makeText(MainActivity.this,
                        e.toString(), Toast.LENGTH_SHORT).show();
            }
            return response;
        }

        /**
         * Display the filling feedback (loading)
         */
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            progressBar.setVisibility(View.VISIBLE);
        }

        /**
         * onPostExecute method to process the response
         * @param response The result of the operation computed by {@link #doInBackground}.
         *
         */
        //onPostExecute metódus létrehozása a válasz feldolgozásához
        @Override
        protected void onPostExecute(Response response) {
            super.onPostExecute(response);
            progressBar.setVisibility(View.GONE);
            if (response.getResponseCode() >= 400) {
                Toast.makeText(MainActivity.this, "Hiba történt a kérés feldolgozása során", Toast.LENGTH_SHORT).show();
                Log.d("onPostExecuteError:", response.getContent());
            } else if (requestType.equals("POST")) {
                    Toast.makeText(MainActivity.this, "Sikeres bejelentkezés", Toast.LENGTH_SHORT).show();
                    Intent intent = new Intent(MainActivity.this, ChoicesActivity.class);
                    startActivity(intent);
                    finish();
            }
        }
    }
}