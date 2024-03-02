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
        Schema::create('guests', function (Blueprint $table) {
            $table->id();
            $table->string("g_name", 50)->unique();
            $table->char("g_chip", 15)->nullable();
            $table->enum("g_species", array("kutya", "macska"));
            $table->enum("g_gender", array("nőstény", "hím", "ismeretlen"));
            $table->date("g_in_date")->nullable();
            $table->string("g_in_place", 50);
            $table->date("g_out_date")->nullable();  // ->nullable() lehet nulla
            $table->enum("g_adoption", array("igen", "nem"));
            $table->text("other")->nullable();
            $table->binary("g_image")->nullable();  // composer require doctrine/dbal -t kell használni!!!!!!
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('guests');
    }
};
