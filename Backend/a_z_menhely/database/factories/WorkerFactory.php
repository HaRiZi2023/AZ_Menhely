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

            "w_name" => fake()->name(),
            "w_password" => fake()->lexify(),
            "w_permission" => fake()->randomKey(['a'=> 1, 'b'=> 2, 'c'=> 3]),

        ];
    }
}
