#!/bin/bash

cd ./DecisionTime.ThrowBack/
dotnet publish -c release -r win-x64 -o bin/dist/DecisionTime-Windows --self-contained true
dotnet publish -c release -r osx-x64 -o bin/dist/DecisionTime-Mac --self-contained true
cd ./bin/dist/
zip -r DecisionTimeDemo-Win.zip DecisionTime-Windows
zip -r DecisionTimeDemo-Mac.zip DecisionTime-Mac