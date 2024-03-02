package com.example.animalrescue;


public class Animals {
    private int id;
    private String choice;
    private String species;
    private String gender;
    private String injury;
    private String position;
    private long image;

    public Animals(int id, String choice, String species, String gender, String injury, String name, String position, long image) {
        this.id = id;
        this.choice = choice;
        this.species = species;
        this.gender = gender;
        this.injury = injury;
        this.position = position;
        this.image = image;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getChoice() {
        return choice;
    }

    public void setChoice(String choice) {
        this.choice = choice;
    }

    public String getSpecies() {
        return species;
    }

    public void setSpecies(String species) {
        this.species = species;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public String getInjury() {
        return injury;
    }

    public void setInjury(String injury) {
        this.injury = injury;
    }

    public String getPosition() {
        return position;
    }

    public void setPosition(String position) {
        this.position = position;
    }

    public long getImage() {
        return image;
    }

    public void setImage(long image) {
        this.image = image;
    }
}


