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
            $table->enum("f_choice", array("keres", "talált"));
            $table->enum("f_species", array("kutya", "macska"));
            $table->enum("f_gender", array("nőstény", "hím", "ismeretlen"));
            $table->enum("f_injury", array("igen", "nem"));
            $table->string("f_position", 100);
            $table->string("u_name", 100);
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
