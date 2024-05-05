<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Http\Requests\StoreUserRequest;
use App\Http\Requests\UpdateUserRequest;
use Illuminate\Support\Facades\Hash;
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
        $user=User::all();
        return response()->json($user);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request) //(StoreUserRequest)
    {
         // Ellenőrizzük a jelszót regex-szel
         $password = $request->input('w_password');
         $pattern = "/^(?=.*[a-záéíóöőúüű])(?=.*[A-ZÁÉÍÓÖŐÚÜŰ])(?=.*\d).{3,10}$/";
         if (!preg_match($pattern, $password))
         {
             return response()->json(['error' => 'Jelszónak tartalmaznia kell min:3 max:10 karaktert, amiben legalább egy kisbetű, egy nagybetű és egy szám szerepel!'], 400);
         }

         // Hash-eljük a jelszót
         $hashedPassword = Hash::make($password);

         $user = User::create([
             'name' => $request->input('name'),
             'password' => $hashedPassword,
             'role' => $request->input('role')
         ]);

         return response()->json($user, 201);



        /*
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
        */
    }

    /**
     * Display the specified resource.
     */
    public function show(int $id)
    {
        $user = User::find($id);
        if (is_null($user)) {
            return response()->json(["message" => "Nincs dolgozó az alábbi azonosítóval: $id"], 404);
        }
        return response()->json($user);
    }

    public function update(UpdateUserRequest $request, int $id)
    {
        $user = User::find($id);
        if (is_null($user)) {
            return response()->json(["message" => "Nincs dolgozó az alábbi azonosítóval: $id"], 404);
        }
        $user->fill($request->all());
        $user->save();
        return response()->json($user, 200);


        /*
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

        */
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(int $id)
    {
        $user = User::find($id);
        if (is_null($user)) {
            return response()->json(["message" => "Nincs dolgozó az alábbi azonosítóval: $id"], 404);
        }
        $user->delete();
        return response()->noContent();
    }

    /*********/
    // Adpotionhoz
    public function allUsersData()
    {
        $users = User::all();
        return response()->json($users);
    }


    public function changePassword(Request $request, $id)
    {
        $user = User::findOrFail($id);

        $oldPassword = $request->input('oldPassword');
        $newPassword = $request->input('newPassword');

        if (Hash::check($oldPassword, $user->password)) {
            $user->password = Hash::make($newPassword);
            $user->save();

            return response()->json($user);
        } else {
            return response()->json(['error' => 'The old password is incorrect'], 400);
        }
    }


    public function updateProfile(Request $request, $id)
    {
        $user = User::findOrFail($id);

        $user->name = $request->input('name');
        $user->address = $request->input('address');
        $user->phone = $request->input('phone');
        $user->email = $request->input('email');

        $user->save();

        return response()->json($user);
    }
}
