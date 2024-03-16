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

            "f_choice" => fake()->randomKey(['keres'=> 1, 'talált'=> 2]),
            "f_species" => fake()->randomKey(['kutya'=> 1, 'macska'=> 2]),
            "f_gender" => fake()->randomKey(['nőstény'=> 1, 'hím'=> 2, 'ismeretlen'=> 3]),
            "f_injury" => fake()->randomKey(['igen'=> 1, 'nem'=> 2]),
            "f_position" => fake()->address(),
            "u_name" => fake()->name(),
            "f_other" => fake()->words(3, true),
            "f_image" => fake()->image(null, 360, 360, 'animals', true),
            
        ];
    }
}
