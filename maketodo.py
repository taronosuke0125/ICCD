
def maketodo():
    mo="朝ごはんを一つ"
    lu=""
    di=""

    """下のコードのtextのところに入れたいプロンプトを書いてください。"""

    text = mo.strip()
    text = lu.strip()
    text = di.strip()
    inputs = tokenizer(build_prompt(text), add_special_tokens=False, return_tensors='pt')

    with torch.no_grad():
        dina_ids = model.generate(
            inputs['input_ids'].to(model.device),
            max_new_tokens=256,
            do_sample=True,
            temperature=0.1,
            top_p=0.9,
            pad_token_id=tokenizer.pad_token_id,
            bos_token_id=tokenizer.bos_token_id,
            eos_token_id=tokenizer.eos_token_id,
            repetition_penalty=1.1,
        )

    dina = tokenizer.decode(dina_ids.tolist()[0])
    print(dina)

    text=dina+"の作り方のto do listを作ってください。その際に1...2...3...というふうに書いてください。"

    inputs = tokenizer(build_prompt(text), add_special_tokens=False, return_tensors='pt')

    with torch.no_grad():
        dina_ids = model.generate(
            inputs['input_ids'].to(model.device),
            max_new_tokens=256,
            do_sample=True,
            temperature=0.1,
            top_p=0.9,
            pad_token_id=tokenizer.pad_token_id,
            bos_token_id=tokenizer.bos_token_id,
            eos_token_id=tokenizer.eos_token_id,
            repetition_penalty=1.1,
        )

    dina = tokenizer.decode(dina_ids.tolist()[0])
    print(dina)