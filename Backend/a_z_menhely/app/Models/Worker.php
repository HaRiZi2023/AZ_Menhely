<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Worker extends Model
{
    use SoftDeletes, HasFactory;

    protected $table = 'workers';
    protected $fillable = ['w_name', 'w_password', 'w_permission'];
    protected $visible = ['id', 'w_name', 'w_password', 'w_permission'];
}
