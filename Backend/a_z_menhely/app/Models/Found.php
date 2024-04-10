<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Found extends Model
{
    use HasFactory;

    protected $table = 'founds';
    protected $fillable = ['f_choice', 'f_species', 'f_gender', 'f_injury', 'f_position', 'f_other' , 'f_image'];
    protected $visible = ['id', 'f_choice', 'f_species', 'f_gender', 'f_injury', 'f_position', 'f_other' , 'f_image'];

}

