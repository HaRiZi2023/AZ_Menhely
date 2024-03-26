package com.example.animalrescue;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.location.Address;
import android.location.Geocoder;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.provider.MediaStore;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Spinner;
import android.widget.Toast;
import android.location.Location;

import com.google.gson.Gson;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.util.List;
import java.util.Locale;

public class LostOrFindActivity extends AppCompatActivity {

    private Spinner spinnerFindSearchSp, spinnerASpecies, spinnerAGender, spinnerAInjury;
    private static final String[] findsearch = {"Keres", "Talált"};
    private static final String[] species = {"Kutya", "Macska"};
    private static final String[] gender = {"Ismeretlen", "Nőstény", "Hím"};
    private static final String[] injury = {"Ismeretlen", "Igen", "Nem"};
    private double longitude;
    private double latitude;
    private LocationManager locationManager;
    private LocationListener locationListener;
    private String requestUrl = "http://10.0.2.2:8000/api/founds";
    private EditText editTextAPosition, editTextANote;
    private TextView textViewlocation, textViewBase64;
    private Button buttonAPosition, buttonFoto, buttonSave;
    private ImageView imageViewResult;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_animal);
        init();
/*
        if (ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_FINE_LOCATION)
                != PackageManager.PERMISSION_GRANTED &&
                ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_COARSE_LOCATION)
                        != PackageManager.PERMISSION_GRANTED) {

            textViewlocation.setText(R.string.no_gps_permission);

            // Engedély kérés ablak megnyitása.
            String[] permissions =
                    new String[]{
                            android.Manifest.permission.ACCESS_FINE_LOCATION,
                            Manifest.permission.ACCESS_COARSE_LOCATION
                    };
            ActivityCompat.requestPermissions(this, permissions, 0);
            return;
        }
        //locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER,
        //        0, 0, locationListener);

 */

        ArrayAdapter<String>adapter = new ArrayAdapter<String>(LostOrFindActivity.this, android.R.layout.simple_spinner_item, findsearch);
        ArrayAdapter<String>adapter1 = new ArrayAdapter<String>(LostOrFindActivity.this, android.R.layout.simple_spinner_item, species);
        ArrayAdapter<String>adapter2 = new ArrayAdapter<String>(LostOrFindActivity.this, android.R.layout.simple_spinner_item, gender);
        ArrayAdapter<String>adapter3 = new ArrayAdapter<String>(LostOrFindActivity.this, android.R.layout.simple_spinner_item, injury);
        spinnerFindSearchSp.setAdapter(adapter);
        spinnerFindSearchSp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener(){
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Log.v("item", (String) parent.getItemAtPosition(position));
                }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
        spinnerASpecies.setAdapter(adapter1);
        spinnerASpecies.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Log.v("item", (String) parent.getItemAtPosition(position));
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
        spinnerAGender.setAdapter(adapter2);
        spinnerAGender.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Log.v("item", (String) parent.getItemAtPosition(position));
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
        spinnerAInjury.setAdapter(adapter3);
        spinnerAInjury.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Log.v("item", (String) parent.getItemAtPosition(position));
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });

        /*
        buttonAPosition.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                locationListener = new LocationListener() {
                    @Override
                    public void onLocationChanged(@NonNull Location location) {
                        longitude = location.getLongitude();
                        latitude = location.getLatitude();
                    }
                };
            }
        });


        buttonFoto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {fenykepezes();
            }
        });
        */

        buttonSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String f_choice = spinnerFindSearchSp.getSelectedItem().toString();
                String f_species = spinnerASpecies.getSelectedItem().toString();
                String f_gender = spinnerAGender.getSelectedItem().toString();
                String f_injury = spinnerAInjury.getSelectedItem().toString();
                String f_position = editTextAPosition.getText().toString();
                String f_other = editTextANote.getText().toString();
                String f_image = textViewBase64.getText().toString();

                if (f_choice.isEmpty() || f_species.isEmpty() || f_gender.isEmpty() || f_injury.isEmpty() || f_position.isEmpty()) {
                    Toast.makeText(LostOrFindActivity.this,
                            "A cím mező kitöltése kötelező!", Toast.LENGTH_SHORT).show();
                    return;
                }

                //új állat létrehozása
                Animals animals = new Animals(0,f_choice,f_species,f_gender,f_injury,f_position,f_other,f_image);
                Gson jsonConverter = new Gson();
                //Post kérés elküldése
                RequestTask task = new RequestTask(requestUrl, "POST", jsonConverter.toJson(animals));
                //Kérés végrehajtása
                task.execute();
            }
        });
    }

    /*
    private void fenykepezes() {
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        startActivityForResult(intent, 1);
    }

    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        // Ha a kamera visszatért
        if (requestCode == 1 && resultCode == RESULT_OK) {
            // A kép adatainak lekérése
            Bundle extras = data.getExtras();
            // A kép megjelenítése
            Bitmap elsoBitmap = (Bitmap) extras.get("data");
            String base64Bitmap = convertImageToBase64(elsoBitmap);
            Bitmap masodikBitmap = convertBase64ToImage(base64Bitmap);
            imageViewResult.setImageBitmap(masodikBitmap);
            textViewBase64.setText(base64Bitmap);
        }
    }

    private String convertImageToBase64(Bitmap bitmap) {
        // A kép átalakítása base64-be
        // A kép átalakítása byte tömbbé, majd base64-be
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        // A kép tömörítése
        // A tömörítési minőség 100%
        // A tömörítési formátum JPEG
        // A tömörített kép byte tömbbe való átalakítása
        bitmap.compress(Bitmap.CompressFormat.JPEG, 100, byteArrayOutputStream);
        // A byte tömb átalakítása base64-be
        byte[] imageBytes = byteArrayOutputStream.toByteArray();
        // A base64 string visszaadása
        return Base64.encodeToString(imageBytes, Base64.DEFAULT);
    }

    private Bitmap convertBase64ToImage(String base64String) {
        // A base64 string átalakítása képpé
        // A base64 string átalakítása byte tömbbé
        byte[] imageBytes = Base64.decode(base64String, Base64.DEFAULT);
        // A byte tömb átalakítása képpé
        // A kép visszaadása
        return BitmapFactory.decodeByteArray(imageBytes, 0, imageBytes.length);
    }

    private String getCompleteAddressString(double latitude, double longitude) {
        String strAdd = "";
        Geocoder geocoder = new Geocoder(this, Locale.getDefault());
        try {
            List<Address> addresses = geocoder.getFromLocation(latitude, longitude, 1);
            if (addresses != null) {
                Address returnedAddress = addresses.get(0);
                StringBuilder strReturnedAddress = new StringBuilder("");

                for (int i = 0; i <= returnedAddress.getMaxAddressLineIndex(); i++) {
                    strReturnedAddress.append(returnedAddress.getAddressLine(i)).append("\n");
                }
                strAdd = strReturnedAddress.toString();
                Log.w("My Current loction address", strReturnedAddress.toString());
            } else {
                Log.w("My Current loction address", "No Address returned!");
            }
        } catch (Exception e) {
            e.printStackTrace();
            Log.w("My Current loction address", "Cannot get Address!");
        }
        return strAdd;
    }
*/
    public void init(){
        spinnerFindSearchSp = findViewById(R.id.spinnerFindSearchSp);
        spinnerASpecies = findViewById(R.id.spinnerASpecies);
        spinnerAGender = findViewById(R.id.spinnerAGender);
        spinnerAInjury = findViewById(R.id.spinnerAInjury);
        editTextAPosition = findViewById(R.id.editTextAPosition);
        editTextANote = findViewById(R.id.editTextANote);
        buttonAPosition = findViewById(R.id.buttonAPosition);
        textViewlocation = findViewById(R.id.textViewlocation);
        buttonFoto = findViewById(R.id.buttonFoto);
        buttonSave = findViewById(R.id.buttonSave);
        textViewBase64 = findViewById(R.id.textViewBase64);
        imageViewResult = findViewById(R.id.imageViewResult);
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
                Toast.makeText(LostOrFindActivity.this,
                        e.toString(), Toast.LENGTH_SHORT).show();
            }
            return response;
        }

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            buttonSave.setEnabled(false);
        }

        //onPostExecute metódus létrehozása a válasz feldolgozásához
        @Override
        protected void onPostExecute(Response response) {
            super.onPostExecute(response);
            buttonSave.setEnabled(true);
            if (response.getResponseCode() >= 400) {
                Log.d("Hiba",response.getContent());
                Toast.makeText(LostOrFindActivity.this, "Hiba történt a kérés feldolgozása során", Toast.LENGTH_SHORT).show();
                return;
            }
            if (requestType.equals("POST")) {
                Toast.makeText(LostOrFindActivity.this, "Sikeres rögzítés", Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(LostOrFindActivity.this, ChoicesActivity.class);
                startActivity(intent);
                finish();
            }
        }
    }
}