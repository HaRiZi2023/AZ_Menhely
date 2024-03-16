package com.example.animalrescue;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
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
import android.widget.Spinner;

import java.io.ByteArrayOutputStream;

public class LostOrFindActivity extends AppCompatActivity {

    private Spinner spinnerFindSearchSp, spinnerASpecies, spinnerAGender, spinnerAInjury;
    private static final String[] findsearch = {"Keres", "Talált"};
    private static final String[] species = {"Kutya", "Macska"};
    private static final String[] gender = {"Ismeretlen", "Nőstény", "Hím"};
    private static final String[] injury = {"Ismeretlen", "Igen", "Nem"};

    private EditText editTextAPosition;
    private Button buttonAPosition, buttonFoto, buttonSave;

    private ImageView imageViewResult;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_animal);
        init();

        ArrayAdapter<String>adapter = new ArrayAdapter<String>(LostOrFindActivity.this, android.R.layout.simple_spinner_item, findsearch);

        spinnerFindSearchSp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener(){
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                Log.v("item", (String) parent.getItemAtPosition(position));
                }


            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        spinnerASpecies.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                switch (position){
                    case 0:
                        break;
                    case 1:
                        break;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        spinnerAGender.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                switch (position){
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        spinnerAInjury.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                switch (position) {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        buttonAPosition.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

            }
        });

        buttonFoto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {fenykepezes();
            }
        });

        buttonSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                addAnimal();
            }
        });

    }

    private void addAnimal(){
        String choice = spinnerFindSearchSp.getSelectedItem().toString();
        String species = spinnerASpecies.getSelectedItem().toString();
        String gender = spinnerAGender.getSelectedItem().toString();
        String injury = spinnerAInjury.getSelectedItem().toString();

    }

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
        editTextAPosition = findViewById(R.id.editTextAPosition);
        buttonAPosition = findViewById(R.id.buttonAPosition);
        buttonFoto = findViewById(R.id.buttonFoto);
        buttonSave = findViewById(R.id.buttonSave);
        imageViewResult = findViewById(R.id.imageViewResult);
    }

}