package com.example.animalrescue;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;

import com.google.android.material.button.MaterialButton;


public class ChoicesActivity extends AppCompatActivity {

    private MaterialButton buttonFindSearch, buttonWeb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
                WindowManager.LayoutParams.FLAG_FULLSCREEN);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_choices);
        init();

        buttonFindSearch.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent= new Intent(ChoicesActivity.this, LostOrFindActivity.class);
                startActivity(intent);
                finish();
            }
        });

        buttonWeb.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                intent.setAction(Intent.ACTION_VIEW);
                intent.addCategory(Intent.CATEGORY_BROWSABLE);
                intent.setData(Uri.parse("http://www.google.hu"));
                startActivity(intent);
                finish();
            }
        });

    }
    public void init() {
        buttonFindSearch = findViewById(R.id.buttonFindSearch);
        buttonWeb = findViewById(R.id.buttonWeb);
    }
}