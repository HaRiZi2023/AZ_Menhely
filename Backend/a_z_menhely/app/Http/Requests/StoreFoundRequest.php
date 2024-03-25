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
            'choice'=>'required|string|max:100',
            'species'=>'required|string|max:100',
            'gender'=>'required|string|max:100',
            'injury'=>'required|string|max:100',
            'position'=>'required|string|max:100',
            'other'=>'nullable|string|max:500|',
            'image'=>'string|max:500|'
        ];
    }
}
