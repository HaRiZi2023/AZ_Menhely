<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\Guest;
use Illuminate\Http\Request;

class GuestController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $guests = Guest::all();
        return $guests;
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $guest = Guest::create($request->all());
        return $guest;
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $guest = Guest::find($id);
        if (is_null($guest)) {
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
        }
        return $guest;
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $guest = Guest::find($id);
        if (is_null($guest)) {
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
        }
        $guest->fill($request->all());
        $guest->save();
        return $guest;
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $guest = Guest::find($id);
        if (is_null($guest)) {
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
        }
        $guest->delete();
        return response()->noContent();
    }

    public function getByChipNumber(Request $request, $chipNumber)
    {
    $guest = Guest::where('g_chip', $chipNumber)->first();

    if (!$guest) {
        return response()->json(['message' => 'Guest not found'], 404);
    }

    return response()->json($guest, 200);
    }



    public function allDog()
    {
    // az összes kutya lekérése adatbázisból
    $dogs = Guest::where('g_species', 'kutya')->get();
    if (!$dogs) {
        return response()->json(['message' => 'Nincs kutya a listában!'], 404);
    }
    return response()->json($dogs, 200);
    }

    public function allCat()
    {
    // az összes kutya lekérése adatbázisból
    $cats = Guest::where('g_species', 'macska')->get();
    if (!$cats) {
        return response()->json(['message' => 'Nincs macska a listában!'], 404);
    }
    return response()->json($cats, 200);
    }



}
