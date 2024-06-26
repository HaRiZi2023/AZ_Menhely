<?php

namespace App\Http\Controllers;

use App\Models\Guest;
use App\Http\Requests\StoreGuestRequest;
use App\Http\Requests\UpdateGuestRequest;

class GuestController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    //Ricsi ezt adtam hozzá hogy a képeket megjelenítse    <<< ----------        ----------->>>         <<< ----------        ----------->>>
    public function index()
    {
        $guest = Guest::all();
        $guest->each(function ($guest) {
            if ($guest->g_image) {
                $imageBlob = $guest->g_image;
                $guest->g_image = base64_encode($imageBlob);
            }
        });
        return $guest;
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(StoreGuestRequest $request)
    {
        //
    }

    /**
     * Display the specified resource.
     */
    public function show(Guest $guest)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(Guest $guest)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(UpdateGuestRequest $request, Guest $guest)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Guest $guest)
    {
        //
    }
}
