<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Worker>
 */
class WorkerFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [

            "w_name" => fake()->firstName(),
            "w_password" => fake()->lexify(),
            "w_permission" => fake()->randomKey(['teljes'=> 1, 'szerkesztő'=> 2, 'felhasználó'=> 3]),

        ];
    }
}
