<?php

use App\Http\Controllers\API\AdoptionController;
use App\Http\Controllers\API\FoundController;
use App\Http\Controllers\API\GuestController;
use App\Http\Controllers\API\WorkerController;
use App\Http\Controllers\API\AuthController;
use App\Http\Controllers\ImageController;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "api" middleware group. Make something great!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});
//Users
Route::post('register',[AuthController::class,'register']);
Route::post('login',[AuthController::class,'login']);


Route::apiResource("/users", AdoptionController::class);

//Adoptions
Route::apiResource("/adoptions", AdoptionController::class);

//Founds
Route::apiResource("/founds", FoundController::class);

//Route::get("/founds/{id}/image", [FoundController::class, 'getImage']);


//Guests
Route::apiResource("/guests", GuestController::class);
   // FormChip
Route::get('guests/chip/{chipNumber}', [GuestController::class, 'getByChipNumber']);
Route::put('guests/chip/{chipNumber}', [GuestController::class, 'chipUpdate']);
   // FormChoice
Route::get('guests/all/cats', [GuestController::class, 'allCat']);
Route::get('guests/all/dogs', [GuestController::class, 'allDog']);

Route::get('/checkname', 'GuestController@checkName'); //


//Workers
Route::apiResource("/workers", WorkerController::class);
//Route::get('workers/checkname', [WorkerController::class, 'inNameInDatabase']);
Route::get('/checkname', 'WorkerController@checkName');
