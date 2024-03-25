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
            $table->string("choice", 100);
            $table->string("species", 100);
            $table->string("gender", 100);
            $table->string("injury", 100);
            $table->string("position", 100);
            $table->string("other", 100)->nullable();
            $table->binary("image")->nullable();
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
