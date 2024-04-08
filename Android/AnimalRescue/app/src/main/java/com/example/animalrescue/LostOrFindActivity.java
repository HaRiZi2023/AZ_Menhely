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
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.provider.MediaStore;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Spinner;
import android.widget.Toast;
import android.location.Location;

import com.google.android.material.button.MaterialButton;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.util.List;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationCallback;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationResult;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.tasks.OnSuccessListener;

public class LostOrFindActivity extends AppCompatActivity {

    private Spinner spinnerFindSearchSp, spinnerASpecies, spinnerAGender, spinnerAInjury;
    private static final String[] findsearch = {"Keres", "Talált"};
    private static final String[] species = {"Kutya", "Macska"};
    private static final String[] gender = {"Ismeretlen", "Nőstény", "Hím"};
    private static final String[] injury = {"Ismeretlen", "Igen", "Nem"};
    private String check;
    private String longitude;
    private String latitude;
    public static final int DEFAULT_UPDATE_INTERVAL = 30;
    public static final int FAST_UPDATE_INTERVAL = 5;
    private static final int PERMISSIONS_FINE_LOCATION = 99;
    private String requestUrl = "http://10.0.2.2:8000/api/founds";
    private TextInputLayout textInputLayoutAPosition;
    private TextInputEditText textInputEditTextAPosition, textInputEditTextANote, textInputEditTextLocation;
    private TextView textViewBase64, textViewLongitude, textViewLatitude, textViewAddress, textViewUpdate;
    private MaterialButton buttonAPosition, buttonFoto, buttonSave, buttonBack;
    private ImageView imageViewResult;
    LocationRequest locationRequest;
    LocationCallback locationCallback;

    //Googles API for location services. the Majority of this apps functions using this class
    FusedLocationProviderClient fusedLocationProviderClient;
    private FusedLocationProviderClient fusedLocationClient;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_lostorfind);
        fusedLocationClient = LocationServices.getFusedLocationProviderClient(this);
        init();

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

        // minden szükséges beállítás a locationRequesthez

        locationRequest = new LocationRequest();

        //a lokációlekérdezés gyakorisága
        locationRequest.setInterval(1000 * DEFAULT_UPDATE_INTERVAL);

        //a lokációgyakoriság felűlírása gyakori lekérdezés esetén

        locationRequest.setFastestInterval(1000 * FAST_UPDATE_INTERVAL);

        locationRequest.setPriority(LocationRequest.PRIORITY_BALANCED_POWER_ACCURACY);

        locationCallback = new LocationCallback() {

            @Override
            public void onLocationResult(LocationResult locationResult) {
                super.onLocationResult(locationResult);

                //lokáció elmentése
                updateUIValues(locationResult.getLastLocation());

            }
        };

        buttonAPosition.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if(buttonAPosition.isPressed()){
                    updateGPS();
                    locationRequest.setPriority(locationRequest.PRIORITY_HIGH_ACCURACY);
                    StartLocationUpdates();
                    if (textViewAddress.getText().toString() == "Nem létezik címadat"){
                        check = latitude + ", " + longitude;
                    }else{
                        check = textViewAddress.getText().toString();
                    }
                }else {
                    locationRequest.setPriority(LocationRequest.PRIORITY_BALANCED_POWER_ACCURACY);
                    stopLocationUpdates();
                }
                textInputEditTextAPosition.setText(check);
                textInputEditTextLocation.setText(latitude + ", " + longitude);
            }
        });

        updateGPS();

        buttonFoto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {fenykepezes();
            }
        });

        buttonSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String f_choice = spinnerFindSearchSp.getSelectedItem().toString();
                String f_species = spinnerASpecies.getSelectedItem().toString();
                String f_gender = spinnerAGender.getSelectedItem().toString();
                String f_injury = spinnerAInjury.getSelectedItem().toString();
                String f_position = textInputEditTextAPosition.getText().toString();
                String f_other = textInputEditTextANote.getText().toString();
                String f_image = textViewBase64.getText().toString();

                if (f_position.isEmpty()) {
                    textInputLayoutAPosition.setError("A mező kitöltése kötelező");
                    Toast.makeText(LostOrFindActivity.this,
                            "Használd az Állat pozíciója gombot!", Toast.LENGTH_SHORT).show();
                    return;
                }else{
                    textInputLayoutAPosition.setError(null);
                }

                //új állat létrehozása
                Animal animal = new Animal(0,f_choice,f_species,f_gender,f_injury,f_position,f_other,f_image);
                Gson jsonConverter = new Gson();
                //Post kérés elküldése
                RequestTask task = new RequestTask(requestUrl, "POST", jsonConverter.toJson(animal));
                //Kérés végrehajtása
                task.execute();
            }
        });
        buttonBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LostOrFindActivity.this, ChoicesActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }

    //Lokáció
    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);

        switch (requestCode) {
            case PERMISSIONS_FINE_LOCATION:
                if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    updateGPS();
                } else {
                    Toast.makeText(this, "Az applikációnak szüksége van az engedélyekre a működéshez.", Toast.LENGTH_SHORT).show();
                }
        }
    }

    private void updateGPS() {
        fusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(LostOrFindActivity.this);

        if (ActivityCompat.checkSelfPermission(LostOrFindActivity.this, Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {

            fusedLocationProviderClient.getLastLocation().addOnSuccessListener(this, new OnSuccessListener<Location>() {
                @Override
                public void onSuccess(Location location) {
                    updateUIValues(location);
                }
            });
        } else {
            //if permission is not granted yet
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                requestPermissions(new String[]{Manifest.permission.ACCESS_FINE_LOCATION}, PERMISSIONS_FINE_LOCATION);
            }
        };
    };

    private void updateUIValues(Location location) {

        if (location != null) {

            textViewLatitude.setText(String.valueOf(location.getLatitude()));
            textViewLongitude.setText(String.valueOf(location.getLongitude()));
            longitude = textViewLongitude.getText().toString();
            latitude = textViewLatitude.getText().toString();

            Geocoder geocoder = new Geocoder(LostOrFindActivity.this);

            try {
                List<Address> addresses = geocoder.getFromLocation(location.getLatitude(),location.getLongitude(),1);
                textViewAddress.setText(addresses.get(0).getAddressLine(0));
            }
            catch (Exception e) {
                textViewAddress.setText("Nem létezik címadat");
            };

        } else {
            textViewLatitude.setText("NA");
            textViewLongitude.setText("NA");
        }
    }

    private void StartLocationUpdates() {
        textViewUpdate.setText("Követve vagy");

        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            return;
        }
        fusedLocationProviderClient.requestLocationUpdates(locationRequest, locationCallback, null);
    }
    private void stopLocationUpdates() {
        textViewUpdate.setText("Nem elérhető");
        textViewLatitude.setText("Nem elérhető");
        textViewLongitude.setText("Nem elérhető");
        fusedLocationProviderClient.removeLocationUpdates(locationCallback);
    }

    //Fényképezés
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

    public void init(){
        spinnerFindSearchSp = findViewById(R.id.spinnerFindSearchSp);
        spinnerASpecies = findViewById(R.id.spinnerASpecies);
        spinnerAGender = findViewById(R.id.spinnerAGender);
        spinnerAInjury = findViewById(R.id.spinnerAInjury);
        textInputLayoutAPosition = findViewById(R.id.textInputLayoutAPosition);
        textInputEditTextAPosition = findViewById(R.id.textInputEditTextAPosition);
        textInputEditTextANote = findViewById(R.id.textInputEditTextANote);
        buttonAPosition = findViewById(R.id.buttonAPosition);
        textInputEditTextLocation = findViewById(R.id.textInputEditTextLocation);
        buttonFoto = findViewById(R.id.buttonFoto);
        buttonSave = findViewById(R.id.buttonSave);
        textViewBase64 = findViewById(R.id.textViewBase64);
        imageViewResult = findViewById(R.id.imageViewResult);
        textViewLatitude = findViewById(R.id.textViewLatitude);
        textViewLongitude = findViewById(R.id.textViewLongitude);
        textViewAddress = findViewById(R.id.textViewAddress);
        textViewUpdate = findViewById(R.id.textViewUpdate);
        buttonBack = findViewById(R.id.buttonBack);
    }

    //Adatbázisba történő mentés, küldés
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