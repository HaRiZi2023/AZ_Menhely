package com.example.animalrescue;
public class Animals {
    private int id;
    private String f_choice;
    private String f_species;
    private String f_gender;
    private String f_injury;
    private String f_position;
    private String f_other;
    private String f_image;

    public Animals(int id, String f_choice, String f_species, String f_gender, String f_injury, String f_position, String f_other, String f_image) {
        this.id = id;
        this.f_choice = f_choice;
        this.f_species = f_species;
        this.f_gender = f_gender;
        this.f_injury = f_injury;
        this.f_position = f_position;
        this.f_other = f_other;
        this.f_image = f_image;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getChoice() {
        return f_choice;
    }

    public void setChoice(String f_choice) {
        this.f_choice = f_choice;
    }

    public String getSpecies() {
        return f_species;
    }

    public void setSpecies(String f_species) {
        this.f_species = f_species;
    }

    public String getGender() {
        return f_gender;
    }

    public void setGender(String f_gender) {
        this.f_gender = f_gender;
    }

    public String getInjury() {
        return f_injury;
    }

    public void setInjury(String f_injury) {
        this.f_injury = f_injury;
    }

    public String getPosition() {
        return f_position;
    }

    public void setPosition(String f_position) {
        this.f_position = f_position;
    }

    public String getOther() {
        return f_other;
    }

    public void setOther(String f_other) { this.f_other = f_other; }

    public String getImage() {
        return f_image;
    }

    public void setImage(String f_image) {
        this.f_image = f_image;
    }
}


