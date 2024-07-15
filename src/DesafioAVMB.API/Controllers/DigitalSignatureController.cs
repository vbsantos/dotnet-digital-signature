using DesafioAVMB.Application.UseCases.CreateEnvelope;
using DesafioAVMB.Application.UseCases.CreateRepository;
using DesafioAVMB.Application.UseCases.CreateSignatory;
using DesafioAVMB.Application.UseCases.GetEnvelope;
using DesafioAVMB.Application.UseCases.GetEnvelopesByRepositorio;
using DesafioAVMB.Application.UseCases.GetFile;
using DesafioAVMB.Application.UseCases.GetRepositories;
using DesafioAVMB.Application.UseCases.SendEnvelope;
using DesafioAVMB.Infrastructure.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAVMB.API.Controllers;

[ApiController]
[Authorize]
[Route("api/digitalSignature")]
public class DigitalSignatureController : ControllerBase
{
    private readonly ICreateRepositoryUseCase _createRepositoryUseCase;
    private readonly ICreateEnvelopeUseCase _createEnvelopeUseCase;
    private readonly ICreateSignatoryUseCase _createSignatoryUseCase;
    private readonly ISendEnvelopeUseCase _sendEnvelopeUseCase;
    private readonly IGetFileUseCase _getFileUseCase;
    private readonly IGetRepositoriesUseCase _getRepositoriesUseCase;
    private readonly IGetEnvelopeUseCase _getEnvelopeUseCase;
    private readonly IGetEnvelopesByRepositorioUseCase _getEnvelopesByRepositorioUseCase;

    public DigitalSignatureController(
        ICreateRepositoryUseCase createRepositoryUseCase,
        ICreateEnvelopeUseCase createEnvelopeUseCase,
        ICreateSignatoryUseCase createSignatoryUseCase,
        ISendEnvelopeUseCase sendEnvelopeUseCase,
        IGetFileUseCase getFileUseCase,
        IGetRepositoriesUseCase getRepositoriesUseCase,
        IGetEnvelopeUseCase getEnvelopeUseCase,
        IGetEnvelopesByRepositorioUseCase getEnvelopesByRepositorioUseCase
    )
    {
        _createRepositoryUseCase = createRepositoryUseCase;
        _createEnvelopeUseCase = createEnvelopeUseCase;
        _createSignatoryUseCase = createSignatoryUseCase;
        _sendEnvelopeUseCase = sendEnvelopeUseCase;
        _getFileUseCase = getFileUseCase;
        _getRepositoriesUseCase = getRepositoriesUseCase;
        _getEnvelopeUseCase = getEnvelopeUseCase;
        _getEnvelopesByRepositorioUseCase = getEnvelopesByRepositorioUseCase;
    }

    /// <summary>
    /// Create a new repository
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("repository")]
    public async Task<IActionResult> CreateRepository(
        [FromBody] CreateRepositoryInputDto input
    )
    {
        var ownerId = User.GetId();

        var response = await _createRepositoryUseCase.Execute(ownerId, input);
        if (response.IsError)
        {
            return BadRequest(response.ErrorsOrEmptyList);
        }

        return Ok(response.Value);
    }

    /// <summary>
    /// Create new envelope
    /// </summary>
    /// <param name="repositoryId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("repository/{repositoryId}/envelope")]
    public async Task<IActionResult> CreateEnvelope(
        [FromRoute] Guid repositoryId,
        [FromBody] CreateEnvelopeInputDto input
    )
    {
        var ownerId = User.GetId();

        var response = await _createEnvelopeUseCase.Execute(ownerId, repositoryId, input);
        if (response.IsError)
        {
            return BadRequest(response.ErrorsOrEmptyList);
        }

        return Ok(response.Value);
    }

    /// <summary>
    /// Add a signatory to an envelope
    /// </summary>
    /// <param name="repositoryId"></param>
    /// <param name="envelopeId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("repository/{repositoryId}/envelope/{envelopeId}/signatory")]
    public async Task<IActionResult> AddEnvelopeSignatory(
        [FromRoute] Guid repositoryId,
        [FromRoute] Guid envelopeId,
        [FromBody] CreateSignatoryInputDto input
    )
    {
        var ownerId = User.GetId();

        var response = await _createSignatoryUseCase.Execute(ownerId, repositoryId, envelopeId, input);
        if (response.IsError)
        {
            return BadRequest(response.ErrorsOrEmptyList);
        }

        return Ok(response.Value);
    }

    [HttpPost("repository/{repositoryId}/envelope/{envelopeId}/send")]
    public async Task<IActionResult> SendEnvelope(
        [FromRoute] Guid repositoryId,
        [FromRoute] Guid envelopeId
    )
    {
        var ownerId = User.GetId();

        var response = await _sendEnvelopeUseCase.Execute(ownerId, repositoryId, envelopeId);
        if (response.IsError)
        {
            return BadRequest(response.ErrorsOrEmptyList);
        }

        return Ok(response.Value);
    }

    [HttpGet("repository/{repositoryId}/envelope/{envelopeId}/file")]
    public async Task<IActionResult> GetFile(
        [FromRoute] Guid repositoryId,
        [FromRoute] Guid envelopeId
    )
    {
        var ownerId = User.GetId();

        var response = await _getFileUseCase.Execute(ownerId, repositoryId, envelopeId);
        if (response.IsError)
        {
            return BadRequest(response.ErrorsOrEmptyList);
        }

        return Ok(response.Value);
    }

    [HttpGet("repository")]
    public async Task<IActionResult> GetRepositories()
    {
        var ownerId = User.GetId();

        var response = await _getRepositoriesUseCase.Execute(ownerId);
        if (response.IsError)
        {
            return BadRequest(response.ErrorsOrEmptyList);
        }

        return Ok(response.Value);
    }

    [HttpGet("repository/{repositoryId}/envelope/{envelopeId}")]
    public async Task<IActionResult> GetEnvelope(
        [FromRoute] Guid repositoryId,
        [FromRoute] Guid envelopeId
    )
    {
        var ownerId = User.GetId();

        var response = await _getEnvelopeUseCase.Execute(ownerId, repositoryId, envelopeId);
        if (response.IsError)
        {
            return BadRequest(response.ErrorsOrEmptyList);
        }

        return Ok(response.Value);
    }

    [HttpGet("repository/{repositoryId}/envelope")]
    public async Task<IActionResult> GetEnvelope(
        [FromRoute] Guid repositoryId
    )
    {
        var ownerId = User.GetId();

        var response = await _getEnvelopesByRepositorioUseCase.Execute(ownerId, repositoryId);
        if (response.IsError)
        {
            return BadRequest(response.ErrorsOrEmptyList);
        }

        return Ok(response.Value);
    }
}
