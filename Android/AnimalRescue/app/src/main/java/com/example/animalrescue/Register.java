package com.example.animalrescue;
public class Register {

    private String email;
    private String password;

    /**
     * Registered User class to authenticate
     * @param email Email address of the registered user
     * @param password Password of the registered user
     */
    public Register(String email, String password) {
        this.email = email;
        this.password = password;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
