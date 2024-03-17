<?php

use App\Http\Controllers\API\AdoptionController;
use App\Http\Controllers\API\FoundController;
use App\Http\Controllers\API\GuestController;
use App\Http\Controllers\API\WorkerController;
use App\Http\Controllers\API\UserController;

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


Route::apiResource("/adoptions", AdoptionController::class);
Route::apiResource("/founds", FoundController::class);
Route::apiResource("/guests", GuestController::class);
Route::apiResource("/workers", WorkerController::class);
Route::apiResource("/users", UserController::class);
