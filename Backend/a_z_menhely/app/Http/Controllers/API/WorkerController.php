<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\API\WorkerController;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;

class WorkerController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $workers = Worker::all();
        return $workers;
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $worker = Worker::create($request->all());
        return $worker;
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $worker = Worker::find($id);
        if (is_null($worker)) {
            return response()->json(["message" => "Nincs hangya az alábbi azonosítóval: $id"], 404);
        }
        return $worker;
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $worker = Worker::find($id);
        if (is_null($worker)) {
            return response()->json(["message" => "Nincs hangya az alábbi azonosítóval: $id"], 404);
        }
        $worker->fill($request->all());
        $worker->save();
        return $worker;
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $worker = Worker::find($id);
        if (is_null($worker)) {
            return response()->json(["message" => "Nincs hangya az alábbi azonosítóval: $id"], 404);
        }
        $worker->delete();
        return response()->noContent();
    }
}
