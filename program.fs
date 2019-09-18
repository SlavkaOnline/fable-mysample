module App

open System
open Fable.Core
open Fable.Core.JsInterop
open Browser
open Browser.Types
open Fable.React
open Fable.React.Props

import "*" "./styles/main.scss"

type MyState = {
    Value :int
}

let appView= 
    FunctionComponent.Of(fun (props: {| initCount: int |}) -> 
        let state = Hooks.useState<MyState>({Value = props.initCount})
        
        let up()  = 
            state.update(fun old -> {old with Value = old.Value + 1})
        
        let down() = 
            state.update(fun old -> {old with Value = old.Value - 1})

        div [] [
                button
                    [OnClick (fun e -> up())]
                    [str "+"]
                div[ClassName "value"] 
                    [str "" ; ofInt state.current.Value]
                button
                    [OnClick (fun e -> down())]
                    [str "-"]
            ]
    )


let render() =
    ReactDom.render(appView({|initCount = 0|}), document.getElementById("app"))

render()