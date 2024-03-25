package com.example.animalrescue;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.gson.Gson;

import java.io.IOException;

public class RegisterActivity extends AppCompatActivity {
    private Button buttonFinalRegister;
    private Button buttonBack;
    private EditText editTextEmailRegister;
    private EditText editTextPasswordRegister;
    private EditText editTextNameRegister;
    private EditText editTextAddressRegister;
    private EditText editTextPhoneRegister;
    private String requestUrl = "http://10.0.2.2:8000/api/users"; //emulátor IP címje, 8000:mert itt fut a beckend

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
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
                String email = editTextEmailRegister.getText().toString();
                String password = editTextPasswordRegister.getText().toString();
                String name = editTextNameRegister.getText().toString();
                String address = editTextAddressRegister.getText().toString();
                String phone = editTextPhoneRegister.getText().toString();

                if (email.isEmpty() || password.isEmpty() || name.isEmpty() || address.isEmpty() || phone.isEmpty()) {
                    Toast.makeText(RegisterActivity.this,
                            "Minden mező kitöltése kötelező!", Toast.LENGTH_SHORT).show();
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
        editTextEmailRegister = findViewById(R.id.editTextEmailRegister);
        editTextPasswordRegister = findViewById(R.id.editTextPasswordRegister);
        editTextNameRegister = findViewById(R.id.editTextNameRegister);
        editTextAddressRegister = findViewById(R.id.editTextAddressRegister);
        editTextPhoneRegister = findViewById(R.id.editTextPhoneRegister);
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