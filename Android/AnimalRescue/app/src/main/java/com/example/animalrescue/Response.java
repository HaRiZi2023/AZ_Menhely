package com.example.animalrescue;

public class Response {
    private int responseCode;
    private String content;

    /**
     * Response class to communication between backend and android
     * @param responseCode
     * @param content
     */
    public Response(int responseCode, String content) {
        this.responseCode = responseCode;
        this.content = content;
    }

    public int getResponseCode() {
        return responseCode;
    }

    public void setResponseCode(int responseCode) {
        this.responseCode = responseCode;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }
}

