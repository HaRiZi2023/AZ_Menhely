<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Http\Requests\LoginRequest;
use App\Http\Requests\RegisterRequest;
use App\Models\User;
use Illuminate\Support\Facades\Hash;

use OpenApi\Annotations as OA;

class AuthController extends Controller
{
    /**
     *
     * Register a new user.
     * Regisztrál egy új felhasználót
     *
     * @OA\Post(
     *     path="/api/register",
     *     tags={"Authentication"},
     *     operationId="register",
     *     summary="Regisztrál egy új felhasználót",
     *     description="Végpont egy új felhasználó regisztrálásához.",
     *     @OA\RequestBody(
     *         required=true,
     *         description="Felhasználó regisztrációs adatai",
     *         @OA\JsonContent(
     *             required={"name", "email", "password", "address", "phone", "role"},
     *             @OA\Property(property="name", type="string", example="John Doe"),
     *             @OA\Property(property="email", type="string", format="email", example="example@example.com"),
     *             @OA\Property(property="password", type="string", example="password"),
     *             @OA\Property(property="address", type="string", example="123 Street, City"),
     *             @OA\Property(property="phone", type="string", example="123-456-789"),
     *             @OA\Property(property="role", type="string", example="user")
     *         )
     *     ),
     *     @OA\Response(
     *         response=201,
     *         description="Sikeres regisztráció",
     *         @OA\Schema(
     *             type="array",
     *             @OA\Items(ref="#/components/schemas/Found")
     *         ),
     *     )
     * )
     *
     * @param RegisterRequest $request A felhasználó adatai validáció után
     * @return JsonResponse a regisztrált felhasználó adatai
     */
    public function register(RegisterRequest $request) {
        // $request->all() nem használható jelszó titkosítása miatt.
        $user = User::create([
            "name" => $request->name,
            "email" => $request->email,
            "password" => Hash::make($request->password),
            "address" => $request->address,
            "phone" => $request->phone,
            "role" => $request->role
        ]);
        return response()->json($user, 201);
    }

    /**
     *
     * Login user and generate authentication token.
     * Bejelentkezteti a felhasználót
     *
     * @OA\Post(
     *     path="/api/login",
     *     tags={"Authentication"},
     *     operationId="login",
     *     summary="Bejelentkezteti a felhasználót és hitelesítési tokent generál",
     *     description="Végpont a felhasználó hitelesítéséhez és hitelesítési token generálásához.",
     *     @OA\RequestBody(
     *         required=true,
     *         description="Bejelentkezési adatok",
     *         @OA\JsonContent(
     *             required={"email", "password"},
     *             @OA\Property(property="email", type="string", format="email", example="example@example.com"),
     *             @OA\Property(property="password", type="string", example="password")
     *         )
     *     ),
     *     @OA\Response(
     *         response=200,
     *         description="Sikeres bejelentkezés",
     *         @OA\JsonContent(
     *             @OA\Property(property="token", type="string", example="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...")
     *         )
     *     ),
     *     @OA\Response(
     *         response=401,
     *         description="Érvénytelen hitelesítő adatok!"
     *     )
     * )
     *
     * @param LoginRequest $request bejelentkezéshez megadott email és jelszó validálva
     * @return JsonResponse a későbbi műveletekhez használandó access-token.
     * A token a json "token" paraméterén érhető el.
     */
    public function login(LoginRequest $request) {
        // Felhasználó megkeresése e-mail alapján és az első találat visszaadása
        $user = User::where("email", $request->email)->first(); // Itt az '->first()' függvényt használva kapsz egy User példányt

        // Ha nem található az e-mail alapján a felhasználó,
        // vagy ha a beírt jelszó nem egyezik meg a regisztrációkor generált jelszóval.
        if(!$user || !Hash::check($request->password, $user->password)){
            return response()->json(["message" => "Érvénytelen hitelesítő adatok!"], 401);
        }
        // Token létrehozása és megjelenítése szöveges formában
        $token = $user->createToken("AuthToken")->plainTextToken;
        // Visszaadjuk a tokent a válaszban, hogy későbbi műveletekhez használható legyen
        return response()->json(["token" => $token]);
    }

    /**
     * Kijelentkezteti a felhasználót
     * Logout user by revoking the current access token.
     *
     * @OA\Post(
     *     path="/api/logout",
     *     tags={"Authentication"},
     *     operationId="logout",
     *     summary="Kijelentkezteti a felhasználót",
     *     description="Végpont a felhasználó kijelentkezésére az aktuális hozzáférési token visszavonásával.",
     *     @OA\Response(
     *         response=204,
     *         description="Sikeres kijelentkezés"
     *     )
     * )
     *
     * @return Response sikeres művelet végrehajtás jelzése.
     */
    public function logout() {
        /*
         auth()->user() visszaadja a sanctum által authentikált felhasználót
         currentAccessToken() az authentikációhoz használt access tokent adja vissza, majd azt töröljük
         alternatívaként currentAccessToken() helyett tokens() függvénnyel az összes access tokent lekérdezhetjük,
         így minden eszközről kijelentkeztethetjük a felhasználót.
         */
        /** @disregard P1013 Undefinded method */
        auth()->user()->currentAccesToken()->delete();

        return response()->noContent();
    }

    // ez is pluszba lett betéve ! ---> Ricsi betette <-------      ---> Ricsi betette <-------         ---> Ricsi betette <-------
    public function logoutEverywhere() {
        $user = auth()->user();
        /** @disregard P1013 Undefined method */
        $user->tokens()->delete();
        return response()->noContent();
    }
}
