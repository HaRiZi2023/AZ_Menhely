package com.example.animalrescue;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

import com.google.android.material.button.MaterialButton;


public class ChoicesActivity extends AppCompatActivity {

    private MaterialButton buttonFindSearch, buttonWeb, buttonLogOut;

    /**
     * Service exchange interface
     * Animal Notification button
     * Go to website for extra information button
     * Logout button
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
        setContentView(R.layout.activity_choices);
        init();

        buttonFindSearch.setOnClickListener(new View.OnClickListener() {
            /**
             * Press the report animal button to be redirected to the reporting interface
             * @param view The view that was clicked.
             */
            @Override
            public void onClick(View view) {
                Intent intent= new Intent(ChoicesActivity.this, LostOrFindActivity.class);
                startActivity(intent);
                finish();
            }
        });

        buttonWeb.setOnClickListener(new View.OnClickListener() {
            /**
             * Pressing the Go to website button will open the animal shelter's Frontend preojekt website in the bonger
             * @param view The view that was clicked.
             */
            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                intent.setAction(Intent.ACTION_VIEW);
                intent.addCategory(Intent.CATEGORY_BROWSABLE);
                intent.setData(Uri.parse("http://10.0.2.2:5173/"));
                startActivity(intent);
                finish();
            }
        });
        buttonLogOut.setOnClickListener(new View.OnClickListener() {
            /**
             * Press the logout button to return to the login screen
             * @param view The view that was clicked.
             */
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(ChoicesActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });

    }

    /**
     * Relationship between Layout and Activity
     */
    public void init() {
        buttonFindSearch = findViewById(R.id.buttonFindSearch);
        buttonWeb = findViewById(R.id.buttonWeb);
        buttonLogOut = findViewById(R.id.buttonLogOut);
    }
}