<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('founds', function (Blueprint $table) {
            $table->id();
            $table->string("f_choice", 100);
            $table->string("f_species", 100);
            $table->string("f_gender", 100);
            $table->string("f_injury", 100);
            $table->string("f_position", 100);
            $table->text("f_other")->nullable();
            $table->binary("f_image")->nullable();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('founds');
    }
};
