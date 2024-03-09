<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\Found;
use Illuminate\Http\Request;

class FoundController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $founds = Found::all();
        return $founds;
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $found = Found::create($request->all());
        return $found;
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $found = Found::find($id);
        if (is_null($found)) {
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
        }
        return $found;
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $found = Found::find($id);
        if (is_null($found)) {
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
        }
        $found->fill($request->all());
        $found->save();
        return $found;
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $found = Found::find($id);
        if (is_null($found)) {
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
        }
        $found->delete();
        return response()->noContent();
    }
}
