<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\Found;
use App\Http\Requests\StoreFoundRequest;
use App\Http\Requests\UpdateFoundRequest;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;
use Illuminate\Support\Facades\File;

use OpenApi\Annotations as OA;

/**
 * @OA\Info(
 *     title="AZ Menhely Backend",
 *     version="0.1"
 * )
 */

class FoundController extends Controller
{
    /**
     * Display a listing of the resource.
     * Összes bejelentett állat listázása
     *
     * @OA\Get(
     *     path="/api/founds",
     *     summary="Összes bejelentett állat listázása",
     *     tags={"Found"},
     *     description="Display a listing of the resource.",
     *     @OA\Response(
     *         response="200",
     *         description="Sikeres művelet",
     *         @OA\Schema(
     *             type="array",
     *             @OA\Items(ref="#/components/schemas/Found")
     *         ),
     *     ),
     * )
     *
     * @return JsonResponse bejelentett állatok listázása
     */
    public function index()
    {
        $founds=Found::all();
        return response()->json($founds);
    }

    /**
     * Store a newly created resource in storage.
     * Bejelentett állat tárolása az adatbázisban
     *
     * @OA\Post(
     *     path="/api/storeFound",
     *     tags={"Found"},
     *     operationId="storeFound",
     *     summary="Bejelentett állat tárolása az adatbázisban",
     *     description="Végpont az újonnan talált objektum tárolására",
     *     @OA\RequestBody(
     *         required=true,
     *         description="Tárolandó bejelentett állat objektum",
     *          @OA\Schema(
     *              type="array",
     *              @OA\Items(ref="#/components/schemas/Found")
     *          ),
     *     ),
     *     @OA\Response(
     *         response=201,
     *         description="Sikeres művelet",
     *         @OA\Schema(
     *              type="array",
     *              @OA\Items(ref="#/components/schemas/Found")
     *         ),
     *     ),
     *     @OA\Response(
     *         response=400,
     *         description="Hiba a kérés feldolgozása során"
     *     )
     * )
     *
     * @param StoreFoundRequest $request
     * @return JsonResponse bejelentett állat rögzítése
     */
    public function storeFound(StoreFoundRequest $request)
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
     * Display the specified found resource.
     * Bejelentett állat megjelenítése
     *
     * @OA\Get(
     *     path="/api/found/{id}",
     *     tags={"Found"},
     *     operationId="show",
     *     summary="Bejelentett állat megjelenítése",
     *     description="Végpont egy meglévő bejelentett állat megjelenítéséhez.",
     *     @OA\Parameter(
     *         name="id",
     *         in="path",
     *         description="A megjelenítendő bejelentett állat azonosítója",
     *         required=true,
     *         @OA\Schema(
     *             type="integer",
     *             format="int64"
     *         )
     *     ),
     *     @OA\Response(
     *         response=200,
     *         description="Sikeres művelet",
     *         @OA\Schema(
     *              type="array",
     *              @OA\Items(ref="#/components/schemas/Found")
     *         ),
     *     ),
     *     @OA\Response(
     *         response=404,
     *         description="A megadott azonosítóval nem található állat."
     *     )
     * )
     *
     * @param int $id A megjelenítendő bejelentett állat azonosítója
     * @return \Illuminate\Http\JsonResponse
     */
    public function show(int $id)
    {
        $found = Found::find($id);
        if (is_null($found)) {
            return response()->json(["message" => "A megadott azonosítóval nem található állat."], 404);
        }
        return response()->json($found);
    }

    /*
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
    */

    /**
     * Remove the specified found resource from storage.
     * Bejelentett állat törlése
     *
     * @OA\Delete(
     *     path="/api/found/{id}",
     *     tags={"Found"},
     *     operationId="destroy",
     *     summary="Bejelentett állat törlése",
     *     description="Végpont egy meglévő bejelentett állat törlésére.",
     *     @OA\Parameter(
     *         name="id",
     *         in="path",
     *         description="A törlendő bejelentett állat azonosítója",
     *         required=true,
     *         @OA\Schema(
     *             type="integer",
     *             format="int64"
     *         )
     *     ),
     *     @OA\Response(
     *         response=204,
     *         description="Sikeres törlés"
     *     ),
     *     @OA\Response(
     *         response=404,
     *         description="A megadott azonosítóval nem található állat."
     *     )
     * )
     *
     * @param int $id A törlendő bejelentett állat azonosítója
     * @return Response
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

    public function update(UpdateFoundRequest $request, int $id)
    {
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

    //Ricsi ezt adtam hozzá hogy a képeket megjelenítse     <<<------------------------------->>>           <<<------------------------------->>>       <<<------------------------------->>>
    public function getImage($id)
    {
        $found = Found::find($id);
        $imageBase64 = $found->f_image;
        // A Base64 string dekódolása és PNG képként való mentése
        $imageBlob = base64_decode($imageBase64);
        return response($imageBlob)->header('Content-Type', 'image/png');
    }














}
