<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Guest extends Model
{
    use SoftDeletes, HasFactory;

    protected $table = 'guests';
    protected $fillable = ['g_name', 'g_chip', 'g_species', 'g_gender', 'g_in_date', 'g_in_place' , 'g_out_date', 'g_adoption', 'g_other', 'g_image'];
    protected $visible = ['id', 'g_name', 'g_chip', 'g_species', 'g_gender', 'g_in_date', 'g_in_place' , 'g_out_date', 'g_adoption', 'g_other', 'g_image'];

    public function getByChipNumber($chipNumber)
    {
        return self::where('g_chip', $chipNumber)->first();
    }
}
