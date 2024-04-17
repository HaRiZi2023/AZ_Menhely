<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use Illuminate\Support\Facades\Hash;
use App\Models\Worker;
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
          // Ellenőrizzük a jelszót regex-szel
        $password = $request->input('w_password');
        $pattern = "/^(?=.*[a-záéíóöőúüű])(?=.*[A-ZÁÉÍÓÖŐÚÜŰ])(?=.*\d).{3,10}$/";
        if (!preg_match($pattern, $password))
        {
            return response()->json(['error' => 'Jelszónak tartalmaznia kell min:3 max:10 karaktert, amiben legalább egy kisbetű, egy nagybetű és egy szám szerepel!'], 400);
        }

        // Hash-eljük a jelszót
        $hashedPassword = Hash::make($password);

        $worker = Worker::create([
            'w_name' => $request->input('w_name'),
            'w_password' => $hashedPassword,
            'w_permission' => $request->input('w_permission')
        ]);

        return $worker;
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $worker = Worker::find($id);
        if (is_null($worker)) {
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
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
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
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
            return response()->json(["message" => "Nincs elem az alábbi azonosítóval: $id"], 404);
        }
        $worker->delete();
        return response()->noContent();
    }

    public function checkName(Request $request)
    {
        $w_name = $request->get('w_name');
        $exists = Worker::where('w_name', $w_name)->exists();
        return response()->json($exists);
    }

    

}


