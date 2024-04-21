<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\Adoption;
use Illuminate\Http\Request;

class AdoptionController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $adoptions = Adoption::all();
        return $adoptions;
    }

    /**
     * Store a newly created resource in storage.
     */
    /*public function store(Request $request)
    {

        $adoption = Adoption::create($request->all());
        return $adoption;
    }*/

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $adoption = Adoption::find($id);
        if (is_null($adoption)) {
            return response()->json(["message" => "Nincs örökbefogadás az alábbi azonosítóval: $id"], 404);
        }
        return $adoption;
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $adoption= Adoption::find($id);
        if (is_null($adoption)) {
            return response()->json(["message" => "Nincs örökbefogadás az alábbi azonosítóval: $id"], 404);
        }
        $adoption->fill($request->all());
        $adoption->save();
        return $adoption;
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $adoption = Adoption::find($id);
        if (is_null($adoption)) {
            return response()->json(["message" => "Nincs örökbefogadás az alábbi azonosítóval: $id"], 404);
        }
        $adoption->delete();
        return response()->noContent();
    }

    /***/

    public function store(Request $request)
    {
        $adoption = new Adoption;
        $adoption->A_date = $request->A_date;
        $adoption->G_name = $request->G_name;
        $adoption->U_name = $request->U_name;
        $adoption->Created_at = $request->Created_at;
        $adoption->Updated_at = $request->Updated_at;
        $adoption->save();

        return response()->json($adoption, 201);
    }

}
