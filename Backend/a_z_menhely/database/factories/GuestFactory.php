<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Guest>
 */
class GuestFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [

            "g_name" => fake()->lastName(),
            "g_chip" => fake()->randomNumber(15, true),
            "g_species" => fake()->randomKey(['a'=> 1, 'b'=> 2]),
            "g_gender" => fake()->randomKey(['a'=> 1, 'b'=> 2, 'c'=> 3]),
            "g_in_date" => fake()->date(),
            "g_in_place" => fake()->address(),
            "g_out_date" => fake()->date(),
            "g_adoption" => fake()->randomKey(['a'=> 1, 'b'=> 2]),
            "other" => fake()->words(3),
            "g_image" => fake()->image(null, 360, 360, 'animals', true),

        ];
    }
}
