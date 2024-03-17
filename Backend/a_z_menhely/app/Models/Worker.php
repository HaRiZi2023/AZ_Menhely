<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Worker extends Model
{
    use HasFactory;

    protected $table = 'workers';
    protected $fillable = ['w_name', 'w_password', 'w_permission'];
    protected $visible = ['id', 'w_name', 'w_password', 'w_permission'];
}
