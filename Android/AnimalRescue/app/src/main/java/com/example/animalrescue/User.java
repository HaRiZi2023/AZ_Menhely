package com.example.animalrescue;
public class User {

    private int id;
    private String email;
    private String password;
    private String name;
    private String address;
    private String phone;
    private String role;

    /**
     * User class for reporting to the backend
     * @param id AUTO_INCREMENT, primary key
     * @param email User email address
     * @param password User password
     * @param name User full name
     * @param address User address
     * @param phone User phonenumber
     * @param role User policy - Admin, Worker, User
     */
    public User(int id, String email, String password, String name, String address, String phone, String role) {
        this.id = id;
        this.email = email;
        this.password = password;
        this.name = name;
        this.address = address;
        this.phone = phone;
        this.role = role;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
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

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) { this.phone = phone; }

    public String getRule() { return role; }

    public void setRule(String rule) { this.role = role; }
}
