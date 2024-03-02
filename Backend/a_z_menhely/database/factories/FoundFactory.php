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

            "f_choice" => fake()->randomKey(['a'=> 1, 'b'=> 2]),
            "f_species" => fake()->randomKey(['a'=> 1, 'b'=> 2]),
            "f_gender" => fake()->randomKey(['a'=> 1, 'b'=> 2, 'c'=> 3]),
            "f_injury" => fake()->randomKey(['a'=> 1, 'b'=> 2]),
            "f_position" => fake()->address(),
            "u_name" => fake()->name(),
            "f_other" => fake()->words(3),
            "f_image" => fake()->image(null, 360, 360, 'animals', true),   //





            "name" => fake()->name(),
            "szam" => fake()->randomNumber(4, true),
            "enum" => fake()->randomKey(['a'=> 1, 'b'=> 2, 'c'=> 3]),
            //"date" => fake()->year("-1 year), ha csak év kell
            "date" => fake()->date(), //év-hó-nap
        ];
    }
}
