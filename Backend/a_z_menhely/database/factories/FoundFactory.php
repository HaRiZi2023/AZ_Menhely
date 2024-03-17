<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Found>
 */
class FoundFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [

            "f_choice" => fake()->firstName(),
            "f_species" => fake()->firstName(),
            "f_gender" => fake()->firstName(),
            "f_injury" => fake()->firstName(),
            "f_position" => fake()->address(),
            "f_other" => fake()->words(3, true),
            "f_image" => fake()->image(null, 360, 360, 'animals', true),

        ];
    }
}
