<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreFoundRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     */
    public function authorize(): bool
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, \Illuminate\Contracts\Validation\ValidationRule|array<mixed>|string>
     */
    public function rules(): array
    {
        return [
            'f_choice'=>'required|string|max:100',
            'f_species'=>'required|string|max:100',
            'f_gender'=>'required|string|max:100',
            'f_injury'=>'required|string|max:100',
            'f_position'=>'required|string|max:100',
            'f_other'=>'nullable|string|max:500|',
            'f_image'=>'string|max:500|'
        ];
    }
}
