<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;
use Illuminate\Support\Facades\Hash;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Worker>
 */
class WorkerFactory extends Factory
{
    /**
     * The current password being used by the factory.
     */
    protected static ?string $w_password;

    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [

            "w_name" => fake()->firstName(),
            "w_password" => static ::$w_password ??= Hash::make('w_password'),
            "w_permission" => fake()->randomKey(['teljes'=> 1, 'felhasználó'=> 2]),

        ];
    }
}
