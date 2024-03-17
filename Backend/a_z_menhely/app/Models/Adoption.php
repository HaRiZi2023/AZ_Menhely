<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Adoption extends Model
{
    use HasFactory;

    protected $table = 'adoptions';
    protected $fillable = ['a_date', 'g_name', 'u_name'];
    protected $visible = ['id', 'a_date', 'g_name', 'u_name'];
}
