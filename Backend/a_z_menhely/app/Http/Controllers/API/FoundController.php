<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\Found;
use App\Http\Requests\StoreFoundRequest;
use App\Http\Requests\UpdateFoundRequest;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;
use Illuminate\Support\Facades\File;

class FoundController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $founds=Found::all();
        return response()->json($founds);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreFoundRequest $request)
    {
        $validator = Validator::make($request->all(), (new StoreFoundRequest())->rules());
        if ($validator->fails()) {
            $errormsg = "";
            foreach ($validator->errors()->all() as $error) {
                $errormsg .= $error . " ";
            }
            $errormsg = trim($errormsg);
            return response()->json(["message" => $errormsg], 400);
        }
        $found = new Found();
        $found->fill($request->all());
        $found->save();
        return response()->json($found, 201);
    }

    /**
     * Display the specified resource.
     */
    public function show(int $id)
    {
        $found = Found::find($id);
        if (is_null($found)) {
            return response()->json(["message" => "A megadott azonosítóval nem található állat."], 404);
        }
        return response()->json($found);
    }

    public function update(UpdateFoundRequest $request, int $id)
    {
        if ($request->isMethod('PUT')) {
            $validator = Validator::make($request->all(), (new StoreFoundRequest())->rules());
            if ($validator->fails()) {
                $errormsg = "";
                foreach ($validator->errors()->all() as $error) {
                    $errormsg .= $error . " ";
                }
                $errormsg = trim($errormsg);
                return response()->json($errormsg, 400);
            }
        }
        $found = Found::find($id);
        if (is_null($found)) {
            return response()->json(["message" => "A megadott azonosítóval nem található állat."], 404);
            
        // ez az új
        if ($request->has('F_image')) {
            $request->merge(['F_image' => base64_decode($request->F_image)]);
        }
        // eddig az új

        }
        $found->fill($request->all());
        $found->save();
        return response()->json($found, 200);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(int $id)
    {
        $found = Found::find($id);
        if (is_null($found)) {
            return response()->json(["message" => "A megadott azonosítóval nem található állat."], 404);
        }
        Found::destroy($id);
        return response()->noContent();
    }
    /*
    public function getImage($id)
    {
        $found = Found::find($id);
        if ($found && $found->image) {
            return response()->make($found->image, 200, [
                'Content-Type' => 'application/octet-stream',
                'Content-Disposition' => 'inline; filename="image.jpg"'
            ]);
        } else {
            // Az alapértelmezett kép elérési útja
            $defaultImagePath = public_path('images/Default.png');
            return response()->file($defaultImagePath);
        }
    }*/
        /*
    public function getImage($id)
    {
        $image = Found::table('founds')->where('id', $id)->first();
        $imageData = base64_encode($image->image);
        return response($imageData, 200)
            ->header('Content-Type', 'text/plain');
    }*/















}
