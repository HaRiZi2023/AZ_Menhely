<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Found extends Model
{
    use HasFactory;

    protected $table = 'founds';
    protected $fillable = ['choice', 'species', 'gender', 'injury', 'position', 'other' , 'image'];
    protected $visible = ['id', 'choice', 'species', 'gender', 'injury', 'position', 'other' , 'image'];
}
