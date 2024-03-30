package com.example.animalrescue;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.Toast;
import android.util.Patterns;
import java.util.regex.Pattern;


import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;

import java.io.IOException;

public class RegisterActivity extends AppCompatActivity {
    private static final Pattern PASSWORD_PATTERN =
            Pattern.compile("^" +
                    "(?=.*[@#$%^&+=])" +     // at least 1 special character
                    "(?=\\S+$)" +            // no white spaces
                    ".{4,}" +                // at least 4 characters
                    "$");
    private Button buttonFinalRegister;
    private Button buttonBack;
    private TextInputLayout textInputEditTextNameRegister;
    private TextInputLayout textInputEditTextEmailRegister;
    private TextInputLayout textInputEditTextAddressRegister;
    private TextInputLayout textInputEditTextPhoneRegister;
    private TextInputLayout textInputEditTextPasswordRegister, textInputEditTextPasswordRegister2;
    private String requestUrl = "http://10.0.2.2:8000/api/users"; //emulátor IP címje, 8000:mert itt fut a beckend

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_register);
        init();
        buttonBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(RegisterActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });
        buttonFinalRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String name = textInputEditTextNameRegister.getEditText().getText().toString();
                String email = textInputEditTextEmailRegister.getEditText().getText().toString();
                String address = textInputEditTextAddressRegister.getEditText().getText().toString();
                String phone = textInputEditTextPhoneRegister.getEditText().getText().toString();
                String password = textInputEditTextPasswordRegister.getEditText().getText().toString();

                String emailInput = textInputEditTextEmailRegister.getEditText().getText().toString().trim();
                String passwordInput = textInputEditTextPasswordRegister.getEditText().getText().toString().trim();

                if (email.isEmpty() || password.isEmpty() || name.isEmpty() || address.isEmpty() || phone.isEmpty()) {
                    Toast.makeText(RegisterActivity.this,
                            "Minden mező kitöltése kötelező!", Toast.LENGTH_SHORT).show();
                    return;
                }
                if (!PASSWORD_PATTERN.matcher(passwordInput).matches()){
                    Toast.makeText(RegisterActivity.this,
                            "A jelszó túl gyenge", Toast.LENGTH_SHORT).show();
                    return;
                }
                if (!Patterns.EMAIL_ADDRESS.matcher(emailInput).matches()){
                    Toast.makeText(RegisterActivity.this,
                            "Az emailcím formátuma nem megfelelő", Toast.LENGTH_SHORT).show();
                    return;
                }

                //új felhasználó létrehozása
                Users users = new Users(0,email,password,name,address,phone);
                Gson jsonConverter = new Gson();
                //Post kérés elküldése
                RequestTask task = new RequestTask(requestUrl, "POST", jsonConverter.toJson(users));
                //Kérés végrehajtása
                task.execute();
            }
        });
    }

    public void init() {
        buttonFinalRegister = findViewById(R.id.buttonFinalRegister);
        buttonBack = findViewById(R.id.buttonBack);
        textInputEditTextEmailRegister = findViewById(R.id.textInputEditTextEmailRegister);
        textInputEditTextPasswordRegister = findViewById(R.id.textInputEditTextPasswordRegister);
        textInputEditTextNameRegister = findViewById(R.id.textInputEditTextNameRegister);
        textInputEditTextAddressRegister = findViewById(R.id.textInputEditTextAddressRegister);
        textInputEditTextPhoneRegister = findViewById(R.id.textInputEditTextPhoneRegister);
    }

    private class RequestTask extends AsyncTask<Void, Void, Response> {
        String requestUrl;
        String requestType;
        String requestParams;

        public RequestTask(String requestUrl, String requestType, String requestParams) {
            this.requestUrl = requestUrl;
            this.requestType = requestType;
            this.requestParams = requestParams;
        }

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