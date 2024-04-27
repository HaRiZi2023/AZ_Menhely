<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class UpdateUserRequest extends FormRequest
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
            'name' => 'required|string|max:100',
            //'email' => 'required|string|max:100',
            'password' => 'required|string|max:100',
            //'address'=>'required|string|max:100',
            //'phone'=>'required|string|min:8|max:20',
            'role' => 'required|in: admin, worker, user'
        ];
    }
}
