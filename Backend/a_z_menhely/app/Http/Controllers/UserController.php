<?php

namespace App\Http\Controllers;

use App\Models\User;
use Illuminate\Http\Request;

class UserController extends Controller
{
    public function update(Request $request, User $user)
    {
        // Ellenőrizd, hogy a bejelentkezett felhasználó módosíthatja-e a felhasználói adatokat
        $this->authorize('update', $user);

        // Frissítsd a felhasználói adatokat
        $user->update($request->all());

        return response()->json($user);
    }

    public function destroy(User $user)
    {
        // Ellenőrizd, hogy a bejelentkezett felhasználó törölheti-e a felhasználói adatokat
        $this->authorize('delete', $user);

        // Töröld a felhasználói adatokat
        $user->delete();

        return response()->json(null, 204);
    }
}
