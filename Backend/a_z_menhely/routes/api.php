<?php

use App\Http\Controllers\API\AdoptionController;
use App\Http\Controllers\API\FoundController;
use App\Http\Controllers\API\GuestController;
use App\Http\Controllers\API\WorkerController;
use App\Http\Controllers\API\AuthController;
use App\Http\Controllers\API\UserController;
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
//Eredeti
Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

/***/
//Route::middleware('auth:api')->get('/user', function (Request $request) {
 //   return $request->user();
//});


//Users Mobil APP
Route::post('register',[AuthController::class,'register']);
Route::post('login',[AuthController::class,'login']);

//Founds Mobil APP
Route::post('storeFound', [FoundController::class,'storeFound']);



Route::apiResource("/users", UserController::class);

//
//Route::get('/users', [UserController::class, 'allUsersData']);
//Route::delete('/guests/{id}', [GuestController::class, 'delete']);

//Adoptions
//Route::apiResource("/adoptions", AdoptionController::class);
Route::post('/adoptions', [AdoptionController::class, 'store']);

//Founds
Route::get('/founds', [FoundController::class, 'index']);
Route::put('/founds/{id}', [FoundController::class, 'update']);
Route::delete('/founds/{id}', [FoundController::class, 'destroy']);

//Route::get("/founds/{id}/image", [FoundController::class, 'getImage']);

//Guests
//Route::post('/guests', [GuestController::class, 'store']);
Route::get('/guests/{id}', [GuestController::class, 'show']);   // g_adatlapok
Route::put('/guests/{id}', [GuestController::class, 'update']); // g_update kép miatt
Route::post('/guests', [GuestController::class, 'saveGuest']); // g_insert kép miatt

Route::delete('/guest/{id}', [GuestController::class, 'destroy']);  // a_insert és g_delelte kép miatt
   // Adoption
Route::get('/guests', [GuestController::class, 'allAdoptableAnimal']);  //a_insert

   // FormChip
Route::get('guests/chip/{chipNumber}', [GuestController::class, 'getByChipNumber']);  // rendben
Route::put('guests/chip/{chipNumber}', [GuestController::class, 'chipUpdate']);

   // FormChoice rendben
Route::get('guests/all/cats', [GuestController::class, 'allCat']); //R cat_list
Route::get('guests/all/dogs', [GuestController::class, 'allDog']); //R dog_list

//Route::get('/checkname', [GuestController::class, 'checkName']); // nem kell

//Workers
//Route::apiResource("/workers", WorkerController::class);
//Route::get('workers/checkname', [WorkerController::class, 'inNameInDatabase']);
//Route::get('/checkname', 'WorkerController@checkName');
