<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;
use Illuminate\Validation\Rule;


class RegisterRequest extends FormRequest
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
        $rules = [
            'name' => 'required|string',
            'password' => 'required|min:8',
            'address' => 'required|string|max:100',
            'phone' => 'required|string|min:8|max:20',
            'role' => 'required|string'
        ];

        // Ha a 'role' 'user', akkor kötelező az email megadása
        if ($this->input('role') === 'user') {
            $rules['email'] = 'required|string|email|unique:users,email';
        } else {
            // Ellenkező esetben, ha 'worker' vagy 'admin', nem kötelező az email
            $rules['email'] = 'nullable|string|email';
        }

        return $rules;
    }
}
