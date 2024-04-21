<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Http\Requests\StoreUserRequest;
use App\Http\Requests\UpdateUserRequest;
use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class UserController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $users=User::all();
        return response()->json($users);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreUserRequest $request)
    {
        $validator = Validator::make($request->all(), (new StoreUserRequest())->rules());
        if ($validator->fails()) {
            $errormsg = "";
            foreach ($validator->errors()->all() as $error) {
                $errormsg .= $error . " ";
            }
            $errormsg = trim($errormsg);
            return response()->json(["message" => $errormsg], 400);
        }
        $user = new User();
        $user->fill($request->all());
        $user->save();
        return response()->json($user, 201);
    }

    /**
     * Display the specified resource.
     */
    public function show(int $id)
    {
        $user = User::find($id);
        if (is_null($user)) {
            return response()->json(["message" => "A megadott azonosítóval nem található állat."], 404);
        }
        return response()->json($user);
    }

    public function update(UpdateUserRequest $request, int $id)
    {
        if ($request->isMethod('PUT')) {
            $validator = Validator::make($request->all(), (new StoreUserRequest())->rules());
            if ($validator->fails()) {
                $errormsg = "";
                foreach ($validator->errors()->all() as $error) {
                    $errormsg .= $error . " ";
                }
                $errormsg = trim($errormsg);
                return response()->json($errormsg, 400);
            }
        }
        $user= User::find($id);
        if (is_null($user)) {
            return response()->json(["message" => "A megadott azonosítóval nem található állat."], 404);
        }
        $user->fill($request->all());
        $user->save();
        return response()->json($user, 200);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(int $id)
    {
        $user = User::find($id);
        if (is_null($user)) {
            return response()->json(["message" => "A megadott azonosítóval nem található bor."], 404);
        }
        User::destroy($id);
        return response()->noContent();
    }

    /*********/
    // Adpotionhoz
    public function allUsersData()
    {
        $users = User::all();
        return response()->json($users);
    }
}
