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

            "g_name" => fake()->firstName(),
            "g_chip" => fake()->numberBetween(900000000000001, 999999999999999), //randomNumber(5,true),   //(15, true),
            "g_species" => fake()->randomKey(['kutya'=> 1, 'macska'=> 2]),
            "g_gender" => fake()->randomKey(['nőstény'=> 1, 'hím'=> 2, 'ismeretlen'=> 3]),
            "g_in_date" => fake()->date(),
            "g_in_place" => fake()->address(),
            "g_out_date" => fake()->date(),
            "g_adoption" => fake()->randomKey(['igen'=> 1, 'nem'=> 2]),
            "other" => fake()->words(3, true),
            "g_image" => fake()->image(null, 360, 360, 'animals', true),

        ];
    }
}
