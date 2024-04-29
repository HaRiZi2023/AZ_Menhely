<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
//use App\Http\Requests\StoreAdoptionRequest;
//use App\Http\Requests\UpdateAdoptionRequest;
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

    public function store(Request $request)  //
    {
        $adoption = new Adoption;
        $adoption->a_date = $request->a_date;
        $adoption->g_name = $request->g_name;
        $adoption->u_name = $request->u_name;
        //$adoption->created_at = $request->created_at;
        //$adoption->updated_at = $request->updated_at;
        $adoption->save();

        return response()->json($adoption, 201);

    }

}
