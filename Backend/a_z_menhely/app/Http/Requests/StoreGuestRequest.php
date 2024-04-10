<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreGuestRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return false;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            'g_name' => 'required|string|max:50',
            'g_chip' => 'nullable|string|size:15|regex:/^9\d{14}$/',
            'g_species' => 'required|in: kutya, macska',
            'g_gender' => 'required|in: nőstény, hím, ismeretlen' ,
            'g_in_date' => 'required|date',
            'g_in_place' =>'required|string|max:100',  
            'g_out_date' => 'nullable|date',
            'g_adoption' => 'required|in: igen, nem',
            'g_other' => 'nullable|string',
            'g_image' => 'nullable|image',
        ];
    }
}
