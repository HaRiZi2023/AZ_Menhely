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
            return response()->json(["message" => "S Nincs elem az alábbi azonosítóval: $id"], 404);
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







    // FormChoice-hoz

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
    // az összes macska lekérése adatbázisból
    $cats = Guest::where('g_species', 'macska')->get();
    if (!$cats) {
        return response()->json(['message' => 'Nincs macska a listában!'], 404);
    }
    return response()->json($cats, 200);
    }


    // FormChip-hez

    public function getByChipNumber(Request $request, $chipNumber)
    {
    $guest = Guest::where('g_chip', $chipNumber)->first();

    if (!$guest) {
        return response()->json(['message' => 'Nincs ilyen vendég'], 404);
    }

    return response()->json($guest, 200);
    }


    public function chipUpdate(Request $request, $chipNumber)
    {
        $guest = Guest::where('g_chip', $chipNumber)->first();

        if (!$guest) {
            return response()->json(['message' => 'Nincs ilyen vendég'], 404);
        }

        $guest->g_other = $request->get('g_other');
        $guest->updated_at = $request->get('updated_at');
        $guest->save();

        return response()->json($guest, 200);
    }

    // Adoptionhoz
    public function allAdoptableAnimal()
    {
        $guests = Guest::where('g_adoption', 'igen')->get();
        return response()->json($guests);
    }

    public function delete(int $id)
    {
        $guest = Guest::find($id);
        if (is_null($guest)) {
            return response()->json(["message" => "Az állat nem található."], 404);
        }
        $guest->delete();
        return response()->json(null, 204);
    }


    /*
    public function updateChipOther(Request $request, $chipNumber)
    {
        $guest = Guest::where('g_chip', $chipNumber)->first();

        if (!$guest) {
            return response()->json(['message' => 'Nincs ilyen vendég'], 404);
        }

        $guest->update($request->all());

        return response()->json($guest, 200);
    }
    */


}

